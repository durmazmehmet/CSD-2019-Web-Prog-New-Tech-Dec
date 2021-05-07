package org.csystem.springboot.app.service;

import org.csystem.springboot.app.entity.DeviceInfo;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;

import java.util.Optional;

public interface IDeviceInfoService {
    Optional<DeviceViewModel> findByName(String name);
    Iterable<DeviceInfo> findAll();
    DeviceInfo save(DeviceInfo di);
    void deleteById(String name);
}
