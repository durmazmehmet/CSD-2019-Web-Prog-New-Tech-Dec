package org.csystem.springboot.app.entity;

import org.apache.tomcat.jni.Local;

import javax.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "devices")
public class Device { // POJO
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "device_id")
    private int m_id;

    @Column(name = "name", nullable = false, length = 100, unique = true)
    private String m_name;

    @Column(name = "host", nullable = false, length = 15)
    private String m_host;

    @Column(name="insert_date")
    private LocalDateTime m_insertDate = LocalDateTime.now();

    public Device()
    {}

    public Device(String name, String host)
    {
        this(0, name, host);
    }

    public Device(int id, String name, String host)
    {
        m_id = id;
        this.m_name = name;
        m_host = host;
    }

    public int getId()
    {
        return m_id;
    }

    public void setId(int id)
    {
        m_id = id;
    }

    public String getName()
    {
        return m_name;
    }

    public void setName(String name)
    {
        m_name = name;
    }

    public String getHost()
    {
        return m_host;
    }

    public void setHost(String host)
    {
        m_host = host;
    }

    public LocalDateTime getInsertDate()
    {
        return m_insertDate;
    }

    public void setInsertDate(LocalDateTime insertDate)
    {
        m_insertDate = insertDate == null ? LocalDateTime.now() : insertDate;
    }

    @Override
    public String toString()
    {
        return String.format("[%d]%s:%s", m_id, m_name, m_host);
    }
}
