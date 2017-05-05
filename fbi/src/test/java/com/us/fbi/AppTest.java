package com.us.fbi;

import java.sql.SQLException;

import org.junit.Test;

import com.us.fbi.service.WomanService;

/**
 * Unit test for simple App.
 */
public class AppTest {
  /* @Test
    public void testApp1() throws SQLException
    {
    	WomanService service=new WomanService();
    	service.insert();
    }
   
   @Test
   public void testApp2() throws SQLException
   {
   	WomanService service=new WomanService();
   	service.findAll();
   }*/
   

  /* @Test
   public void testApp3() throws SQLException
   {
   	WomanService service=new WomanService();
   	service.update();
   }*/
   
   @Test
   public void testApp4() throws SQLException
   {
   	WomanService service=new WomanService();
   	service.deleteById();
   }
}
