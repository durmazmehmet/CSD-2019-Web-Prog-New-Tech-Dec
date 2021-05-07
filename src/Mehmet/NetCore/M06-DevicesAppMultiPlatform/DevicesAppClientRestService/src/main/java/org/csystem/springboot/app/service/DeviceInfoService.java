package org.csystem.springboot.app.service;

import org.csystem.springboot.app.entity.ClientInfo;
import org.csystem.springboot.app.entity.DeviceInfo;
import org.csystem.springboot.app.mapper.IDeviceModelEntityMapper;
import org.csystem.springboot.app.repository.IDeviceInfoRepository;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.csystem.springboot.app.viewmodel.DevicesInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import javax.servlet.http.HttpServletRequest;
import java.util.Optional;

@Service
public class DeviceInfoService implements IDeviceInfoService {
    @Autowired
    private IDeviceInfoRepository m_deviceInfoRepository;

    @Autowired
    private IClientInfoService m_clientInfoService;

    @Autowired
    private HttpServletRequest m_httpServletRequest;

    @Autowired
    private IDeviceModelEntityMapper m_deviceModelEntityMapper;

    @Autowired
    private RestTemplate m_restTemplate;

    @Value("${devicesapp.url}")
    private String m_url;

    private void saveClientInfo(DeviceInfo deviceInfo, boolean found)
    {
        if (deviceInfo ==null)
            return;

        var ci = new ClientInfo(m_httpServletRequest.getRemoteAddr(), deviceInfo.getName(), found);

        m_clientInfoService.save(ci);
    }
    @Override
    public void deleteById(String name)
    {
        m_deviceInfoRepository.deleteById(name);
    }

    @Override
    public Iterable<DeviceInfo> findAll()
    {
        return m_deviceInfoRepository.findAll();
    }

    @Override
    public Optional<DeviceViewModel> findByName(String name)
    {
        var optDeviceInfo = m_deviceInfoRepository.findById(name);
        DeviceInfo deviceInfo = null;
        boolean found = false;

        if (optDeviceInfo.isPresent()) {
            deviceInfo = optDeviceInfo.get();
            found = true;
            saveClientInfo(deviceInfo, found);
            return Optional.of(m_deviceModelEntityMapper.entityToViewModel(deviceInfo));
        }

        var devicesInfo = m_restTemplate.getForObject(m_url + name, DevicesInfo.class);

        var result = devicesInfo.getDevices().stream().findFirst();

        if (result.isPresent()) {
            deviceInfo = m_deviceModelEntityMapper.viewModelToEntity(result.get());
            m_deviceInfoRepository.save(deviceInfo);
        }

        saveClientInfo(deviceInfo, found);
        return result;
    }

    @Override
    public DeviceInfo save(DeviceInfo di)
    {
        return m_deviceInfoRepository.save(di);
    }
}
