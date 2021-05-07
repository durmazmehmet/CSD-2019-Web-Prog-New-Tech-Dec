package org.csystem.springboot.app.viewmodel;

import com.fasterxml.jackson.annotation.JsonInclude;

import java.time.LocalDateTime;

public class DeviceViewModel {
    private String m_name;
    private String m_host;
    private LocalDateTime m_insertDate;

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

    @JsonInclude(JsonInclude.Include.NON_NULL)
    public LocalDateTime getInsertDate()
    {
        return m_insertDate;
    }

    @JsonInclude(JsonInclude.Include.NON_NULL)
    public void setInsertDate(LocalDateTime insertDate)
    {
        m_insertDate = insertDate;
    }

    @Override
    public String toString()
    {
        return String.format("%s:%s %s", m_name, m_host, m_insertDate == null ? "" : m_insertDate);
    }
}
