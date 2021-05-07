package org.csystem.springboot.app.mapper;

import org.csystem.springboot.app.entity.DeviceInfo;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.mapstruct.Mapper;

@Mapper(implementationName = "DeviceModelEntityMapperImpl", componentModel = "spring")
public interface IDeviceModelEntityMapper {
    DeviceInfo viewModelToEntity(DeviceViewModel deviceViewModel);
    DeviceViewModel entityToViewModel(DeviceInfo device);
}
