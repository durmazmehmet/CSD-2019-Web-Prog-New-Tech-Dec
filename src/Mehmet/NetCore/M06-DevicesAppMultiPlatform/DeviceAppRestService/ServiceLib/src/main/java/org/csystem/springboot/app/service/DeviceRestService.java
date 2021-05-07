package org.csystem.springboot.app.service;

import org.csystem.springboot.app.entity.Device;
import org.csystem.springboot.app.repository.IDeviceRepository;
import org.csystem.springboot.app.service.mapper.IDeviceViewModelMapper;
import org.csystem.springboot.app.service.viewmodel.DevicesInfo;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.springframework.stereotype.Service;

import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

@Service
public class DeviceRestService implements IDeviceService {
    private final IDeviceRepository m_deviceRepository;
    private final IDeviceViewModelMapper m_deviceViewModelMapper;

    private Iterable<DeviceViewModel> getDeviceViewModels(Iterable<Device> devices, boolean parallel)
    {
        return StreamSupport
                .stream(devices.spliterator(), parallel)
                .map(d -> m_deviceViewModelMapper.modelToViewModel(d))
                .collect(Collectors.toList());
    }

    public DeviceRestService(IDeviceRepository deviceRepository, IDeviceViewModelMapper deviceViewModelMapper)
    {
        m_deviceRepository = deviceRepository;
        m_deviceViewModelMapper = deviceViewModelMapper;
    }

    @Override
    public DevicesInfo findAll()
    {
        var list = StreamSupport
                .stream(getDeviceViewModels(m_deviceRepository.findAll(), false).spliterator(), false)
                .collect(Collectors.toList());

        return new DevicesInfo(list);
    }

    @Override
    public DeviceViewModel save(DeviceViewModel deviceViewModel)
    {
        //...
        var device = m_deviceViewModelMapper.viewModelToModel(deviceViewModel);

        return m_deviceViewModelMapper.modelToViewModel(m_deviceRepository.save(device));
    }

    @Override
    public DevicesInfo findByName(String name)
    {
        var list = StreamSupport
                .stream(getDeviceViewModels(m_deviceRepository.findByName(name), false).spliterator(), false)
                .collect(Collectors.toList());

        return new DevicesInfo(list);
    }

    @Override
    public Iterable<DeviceViewModel> findByDayAndMonth(int day, int mon)
    {
        //...
        return getDeviceViewModels(m_deviceRepository.findByDayAndMonth(day, mon), false);
    }
}
