package org.csystem.springboot.app.viewmodel;

import java.util.List;

public class DevicesInfo {
    private List<DeviceViewModel> m_deviceViewModels;

    public List<DeviceViewModel> getDevices()
    {
        return m_deviceViewModels;
    }

    public void setDevices(List<DeviceViewModel> deviceViewModels)
    {
        m_deviceViewModels = deviceViewModels;
    }
}
