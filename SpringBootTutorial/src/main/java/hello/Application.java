package main.java.hello;

import java.util.Arrays;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.Bean;

import ch.qos.logback.core.db.dialect.DBUtil;

@SpringBootApplication
public class Application {

/*	@Bean
	public CommandLineR
	
	unner commandLineRunner(ApplicationContext ctx) {
		return args -> {

			System.out
					.println("Let's inspect the beans provided by Spring Boot:");

			String[] beanNames = ctx.getBeanDefinitionNames();
			Arrays.sort(beanNames);
			for (String beanName : beanNames) {
				System.out.println(beanName);
			}

		};
	}*/

	public static void main(String[] args) {
		SpringApplication.run(Application.class, args);

	}

}