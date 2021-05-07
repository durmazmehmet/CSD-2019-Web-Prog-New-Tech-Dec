package org.csystem.springboot.app.controller;

import org.csystem.springboot.app.service.IDeviceInfoService;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("devices")
public class DeviceInfoRestController {
    @Autowired
    private IDeviceInfoService m_deviceInfoService;

    @GetMapping("/names")
    public ResponseEntity<DeviceViewModel> findByName(@RequestParam("name") String name)
    {
        return ResponseEntity.of(m_deviceInfoService.findByName(name));
    }
}
