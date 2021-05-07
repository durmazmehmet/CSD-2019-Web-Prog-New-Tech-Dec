package org.csystem.springboot.app.configuration;

import org.csystem.springboot.app.mapper.IDeviceModelEntityMapper;
import org.csystem.springboot.app.service.IDeviceInfoService;
import org.csystem.springboot.app.viewmodel.DevicesInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.web.client.RestTemplate;

@Configuration
public class SchedulingConfig {
    @Autowired
    private IDeviceInfoService m_deviceInfoService;

    @Autowired
    public RestTemplate m_restTemplate;

    @Autowired
    private IDeviceModelEntityMapper m_deviceModelEntityMapper;

    @Value("${devicesapp.url}")
    private String m_url;

    @Scheduled(fixedRate = 300)
    public void scheduleServiceDBForUpdate()
    {
        m_deviceInfoService.findAll().forEach(di -> {
            var devicesInfo = m_restTemplate.getForObject(m_url + di.getName(), DevicesInfo.class);
            var result = devicesInfo.getDevices().stream().findFirst();

            if (result.isPresent())
                m_deviceInfoService.save(m_deviceModelEntityMapper.viewModelToEntity(result.get()));
            else
                m_deviceInfoService.deleteById(di.getName());
        });
    }
}
