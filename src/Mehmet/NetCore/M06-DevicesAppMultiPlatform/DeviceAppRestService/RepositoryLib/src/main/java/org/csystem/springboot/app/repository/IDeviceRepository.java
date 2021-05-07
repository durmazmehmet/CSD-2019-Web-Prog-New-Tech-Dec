package org.csystem.springboot.app.repository;

import org.csystem.springboot.app.entity.Device;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

public interface IDeviceRepository extends CrudRepository<Device, Integer> {
    @Query("from Device d where d.m_name=?1")
    Iterable<Device> findByName(String name);

    @Query("from  Device d where d.m_name=?1 and d.m_host=?2")
    Iterable<Device> findByNameAndHost(String name, String host);

    @Query(value = "select * from devices d where date_part('day', d.insert_date) =:day and date_part('month', d.insert_date) = :mon",
            nativeQuery = true)
    Iterable<Device> findByDayAndMonth(int day, int mon);
}
