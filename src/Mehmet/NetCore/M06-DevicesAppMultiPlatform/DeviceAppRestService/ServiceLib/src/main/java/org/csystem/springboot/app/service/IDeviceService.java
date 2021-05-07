package org.csystem.springboot.app.service;

import org.csystem.springboot.app.service.viewmodel.DevicesInfo;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;

public interface IDeviceService {
    DeviceViewModel save(DeviceViewModel device);
    DevicesInfo findByName(String name);
    Iterable<DeviceViewModel> findByDayAndMonth(int day, int mon);
    DevicesInfo findAll();
}
