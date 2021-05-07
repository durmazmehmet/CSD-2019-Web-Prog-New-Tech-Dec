package org.csystem.springboot.app.service.viewmodel;

import org.csystem.springboot.app.viewmodel.DeviceViewModel;

import java.util.List;

public class DevicesInfo {
    private List<DeviceViewModel> m_deviceViewModels;

    public DevicesInfo(List<DeviceViewModel> deviceViewModels)
    {
        m_deviceViewModels = deviceViewModels;
    }

    public List<DeviceViewModel> getDevices()
    {
        return m_deviceViewModels;
    }

    public void setDevices(List<DeviceViewModel> deviceViewModels)
    {
        m_deviceViewModels = deviceViewModels;
    }
}
