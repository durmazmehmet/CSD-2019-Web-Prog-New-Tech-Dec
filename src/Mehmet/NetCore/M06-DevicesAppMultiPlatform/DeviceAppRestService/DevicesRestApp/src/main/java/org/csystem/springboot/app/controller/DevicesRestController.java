package org.csystem.springboot.app.controller;

import org.csystem.springboot.app.service.IDeviceService;
import org.csystem.springboot.app.service.viewmodel.DevicesInfo;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
@RequestMapping("/devices")
public class DevicesRestController {
    private final IDeviceService m_deviceService;

    private int getDay(String dayStr)
    {
        int day = 1;

        try {
            day = dayStr.isEmpty() ? 1 : Integer.parseUnsignedInt(dayStr);
        }
        catch (NumberFormatException ex) {
            throw ex;
        }

        return day;
    }

    private int getMon(String monStr)
    {
        int mon = 1;

        try {
            mon = monStr.isEmpty() ? 1 : Integer.parseUnsignedInt(monStr);
        }
        catch (NumberFormatException ex) {
            throw ex;
        }

        return mon;
    }

    public DevicesRestController(IDeviceService deviceService)
    {
        m_deviceService = deviceService;
    }

    @GetMapping("/all")
    public DevicesInfo getAllDevices() //Dikkat veri çoksa yaklaşım farklı olacak
    {
        return m_deviceService.findAll();
    }

    @GetMapping("/names")
    public DevicesInfo getByName(@RequestParam(value = "name", required = false, defaultValue = "") String name)
    {
        return m_deviceService.findByName(name);
    }

    @GetMapping("/info")
    public Iterable<DeviceViewModel> getByDayAndMonth(
            @RequestParam(value = "day", required = false, defaultValue = "-1") int day,
            @RequestParam(value = "mon", required = false, defaultValue = "-1") int mon)
    {
        if (day <= 0)
            day = 1;

        if (mon <= 0)
            mon = 1;

        return m_deviceService.findByDayAndMonth(day, mon);
    }

    @GetMapping("/sinfo")
    public Iterable<DeviceViewModel> getByDayAndMonthStr(
            @RequestParam(value = "day", required = false, defaultValue = "") String dayStr,
            @RequestParam(value = "mon", required = false, defaultValue = "") String monStr)
    {
        Iterable<DeviceViewModel> devices = null;

        try {
            int day = getDay(dayStr);
            int mon = getMon(monStr);

            devices = m_deviceService.findByDayAndMonth(day, mon);
        }
        catch (Throwable ex) {
            devices = new ArrayList<>();
        }

        return devices;
    }

    @PostMapping("/save")
    public DeviceViewModel save(@RequestBody DeviceViewModel deviceViewModel)
    {
        return m_deviceService.save(deviceViewModel);
    }
}
