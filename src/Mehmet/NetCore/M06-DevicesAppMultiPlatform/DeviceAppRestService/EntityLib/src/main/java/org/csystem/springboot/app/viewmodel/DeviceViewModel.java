package org.csystem.springboot.app.viewmodel;

import java.time.LocalDateTime;
import com.fasterxml.jackson.annotation.JsonInclude;

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
}
