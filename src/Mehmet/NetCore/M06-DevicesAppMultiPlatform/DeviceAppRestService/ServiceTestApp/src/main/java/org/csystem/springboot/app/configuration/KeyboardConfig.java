package org.csystem.springboot.app.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.Scanner;

@Configuration
public class KeyboardConfig {
    @Bean
    public Scanner getKeyBoaard()
    {
        return new Scanner(System.in);
    }
}
