package org.csystem.springboot.app.repository;

import org.csystem.springboot.app.entity.DeviceInfo;
import org.springframework.data.repository.CrudRepository;

public interface IDeviceInfoRepository  extends CrudRepository<DeviceInfo, String> {

}
