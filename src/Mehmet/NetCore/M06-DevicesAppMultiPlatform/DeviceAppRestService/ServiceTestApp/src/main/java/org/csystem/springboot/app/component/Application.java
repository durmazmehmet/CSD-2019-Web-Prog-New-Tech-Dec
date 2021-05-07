package org.csystem.springboot.app.component;


import org.csystem.springboot.app.entity.Device;
import org.csystem.springboot.app.service.IDeviceService;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.Scanner;
import java.util.concurrent.ExecutorService;
import java.util.stream.StreamSupport;

@Component
public class Application {
    private final IDeviceService m_deviceService;
    private final ExecutorService m_threadPool;
    private final Scanner m_kb;

    private void run()
    {
        for (;;) {
            StreamSupport
                    .stream(m_deviceService.findByName("melike").spliterator(), false)
                    .findFirst().ifPresent(System.out::println);

            System.out.println("**************");
            StreamSupport
                    .stream(m_deviceService.findByDayAndMonth(26, 1).spliterator(), false)
                    .forEach(System.out::println);

            System.out.print("Cihaz bilgilerini giriniz:");
            System.out.println("İsim giriniz:");
            var name = m_kb.nextLine();

            if (name.equals("quit"))
                break;

            System.out.println("IP giriniz:");
            var host = m_kb.nextLine();

            var device = new Device(name, host);
            m_deviceService.save(device);

            System.out.printf("Eklenen cihaz:%s%n", device);
        }
    }

    public Application(IDeviceService deviceService, ExecutorService threadPool, Scanner kb)
    {
        m_deviceService = deviceService;
        m_threadPool = threadPool;
        m_kb = kb;
    }

    @PostConstruct
    public void runApplication()
    {
        m_threadPool.submit(this::run);
        m_threadPool.shutdown();
    }
}
