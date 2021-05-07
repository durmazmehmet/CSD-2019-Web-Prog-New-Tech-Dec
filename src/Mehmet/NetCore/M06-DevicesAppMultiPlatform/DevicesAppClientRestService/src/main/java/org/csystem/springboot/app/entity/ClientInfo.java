package org.csystem.springboot.app.entity;

import javax.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "clients")
public class ClientInfo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "client_id")
    private long m_id;

    @Column(name = "host", nullable = false)
    private String m_host;

    @Column(name = "device_name", nullable = false)
    private String m_deviceName;

    @Column(name = "query_date", nullable = false)
    private LocalDateTime m_queryDate = LocalDateTime.now();

    @Column(name = "found", nullable = false)
    private boolean m_found;

    public ClientInfo()
    {}

    public ClientInfo(String host, String deviceName, boolean found)
    {
        m_host = host;
        m_deviceName = deviceName;
        m_found = found;
    }

    public long getId()
    {
        return m_id;
    }

    public void setId(long id)
    {
        m_id = id;
    }

    public String getHost()
    {
        return m_host;
    }

    public void setHost(String host)
    {
        m_host = host;
    }

    public String getDeviceName()
    {
        return m_deviceName;
    }

    public void setDeviceName(String deviceName)
    {
        m_deviceName = deviceName;
    }

    public LocalDateTime getQueryDate()
    {
        return m_queryDate;
    }

    public void setQueryDate(LocalDateTime queryDate)
    {
        m_queryDate = queryDate;
    }

    public boolean isFound()
    {
        return m_found;
    }

    public void setFound(boolean found)
    {
        m_found = found;
    }
}
