﻿namespace ShortDev.Microsoft.ConnectedDevices.Transports.Bluetooth;
public sealed class BluetoothTransport(IBluetoothHandler handler) : ICdpTransport, ICdpDiscoverableTransport
{
    public CdpTransportType TransportType { get; } = CdpTransportType.Rfcomm;

    public IBluetoothHandler Handler { get; } = handler;

    public event DeviceConnectedEventHandler? DeviceConnected;
    public async Task Listen(CancellationToken cancellationToken)
    {
        await Handler.ListenRfcommAsync(
            new RfcommOptions()
            {
                ServiceId = Constants.RfcommServiceId,
                ServiceName = Constants.RfcommServiceName,
                SocketConnected = (socket) => DeviceConnected?.Invoke(this, socket)
            },
            cancellationToken
        );
    }

    public async Task<CdpSocket> ConnectAsync(EndpointInfo endpoint)
        => await Handler.ConnectRfcommAsync(endpoint, new RfcommOptions()
        {
            ServiceId = Constants.RfcommServiceId,
            ServiceName = Constants.RfcommServiceName,
            SocketConnected = (socket) => DeviceConnected?.Invoke(this, socket)
        });

    public async Task Advertise(LocalDeviceInfo deviceInfo, CancellationToken cancellationToken)
    {
        await Handler.AdvertiseBLeBeaconAsync(
            new AdvertiseOptions()
            {
                ManufacturerId = Constants.BLeBeaconManufacturerId,
                BeaconData = new BLeBeacon(deviceInfo.Type, Handler.MacAddress, deviceInfo.Name)
            },
            cancellationToken
        );
    }

    public event DeviceDiscoveredEventHandler? DeviceDiscovered;
    public async Task Discover(CancellationToken cancellationToken)
    {
        await Handler.ScanBLeAsync(new()
        {
            OnDeviceDiscovered = (advertisement, rssi) =>
            {
                CdpDevice device = new(
                    advertisement.DeviceName,
                    advertisement.DeviceType,
                    EndpointInfo.FromRfcommDevice(advertisement.MacAddress)
                )
                {
                    Rssi = rssi
                };
                DeviceDiscovered?.Invoke(this, device);
            }
        }, cancellationToken);
    }

    public void Dispose()
    {
        DeviceConnected = null;
    }

    public EndpointInfo GetEndpoint()
        => new(TransportType, Handler.MacAddress.ToStringFormatted(), Constants.RfcommServiceId);
}
