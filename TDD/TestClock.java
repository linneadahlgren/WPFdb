package clock;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.After;
import org.junit.Before;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestClock {
	Clock clock;
	
	
	@BeforeEach
	public void SetUp() throws Exception { 
		clock = new Clock(); 

	}
	@After
	public void tearDown() throws Exception { 
		
	}
	

	// S1 below
	//________________________________________________________________________		
	
	@Test
	void testDisplayTimeToDisplayDate() { //DISPLAY_TIME--> DISPLAY_DATE - (CM)
		assertEquals("2000-1-1", clock.changeMode()); // Legal 1
	}
	
	@Test
	void testDisplayTimeToChangeTime() { // DISPLAY_TIME --> CHANGE_TIME - (R)
		assertEquals("0:0:0",clock.ready()); //Legal 3
	}
	
	@Test
	void testUsingSetInDisplayTime() {  // // Trying to run method set in state DISPLAY_TIME - Illegal (S)
		assertEquals(clock.illegal, clock.set(0,0,0)); // Illegal
	}
	
	// S2 below
//________________________________________________________________________	
	@Test
	void testDisplayDateToDisplayTime() {   //DISPLAY_DATE--> DISPLAY_TIME - (CM)
		clock.changeMode();
		assertEquals("0:0:0", clock.changeMode()); // Legal 2
	}
	@Test
	void testDisplayDateToChangeDate() { //DISPLAY_DATE--> CHANGE_DATE - (R)
		clock.changeMode();
		assertEquals("2000-1-1",clock.ready()); //Legal 3
	}
	@Test
	void testUsingSetInDisplayDate() { //Running method set in state DISPLAY_TIME - Illegal (S)
		clock.changeMode();
		assertEquals(clock.illegal, clock.set(0,0,0)); // Illegal 
	}
	// S3 below
	//________________________________________________________________________	
	@Test
	void testChangeTimeToDisplayTime() { //CHANGE_TIME --> DISPLAY_TIME (S)
		clock.ready();
		assertEquals("10:47:30", clock.set(10, 47, 30));  
	}
	@Test
	void testUsingReadyInChangeTime() {	//Running method ready in state CHANGE_TIME - Illegal (R) 
		clock.ready();
		assertEquals(clock.illegal, clock.ready());
	}
	@Test
	void testUsingChangeModeInChangeTime() { 	// Running method changeMode in state CHANGE_TIME - Illegal (CM)
		clock.ready();
		assertEquals(clock.illegal, clock.changeMode());
	}
	// S4 below
	//________________________________________________________________________	
	@Test 
	void testChangeDateToDisplayDate() {	// CHANGE_DATE --> DISPLAY_DATE (S)
		clock.changeMode();
		clock.ready();
		assertEquals("2020-12-15",clock.set(2020, 12, 15)); 
	}
	@Test
	void testUsingReadyInChangeDate() {		//Running method ready in state CHANGE_DATE - Illegal (R) 
		clock.changeMode();
		clock.ready();
		assertEquals(clock.illegal, clock.ready());
	}
	@Test
	void testUsingChangeModeInChangeDate() {	// Running method changeMode in state CHANGE_DATE - Illegal (CM)
		clock.changeMode();
		clock.ready();
		assertEquals(clock.illegal, clock.changeMode());
	}
	//void testChangeTimeToDisplayDate
	
	
//
//	@Test
//	void testReady() {
//		clock = new Clock(); 
//		assertEquals("0:0:0",clock.ready()); //Legal 3
//		assertEquals("Illegal transition", clock.ready()); //Illegal 1 
//		
//		clock = new Clock();
//		clock.changeMode();
//		assertEquals("2000-1-1",clock.ready()); //Legal 4
//		assertEquals("Illegal transition", clock.ready()); //Illegal 2
//	}
//	
//	@Test
//	void testSet() {
//		clock = new Clock();
//		assertEquals("Illegal transition", clock.set(10, 47, 30)); // Testing Illegal state transition - Illegal 3
//		
//		clock.ready(); // change state to Change Time
//		assertEquals("10:47:30", clock.set(10, 47, 30)); // testing transition to Display Time - Legal 5
//		
//		
//		clock = new Clock();
//		clock.changeMode();
//		assertEquals("Illegal transition", clock.set(2020, 12, 15)); // Testing Illegal state transition - Illegal 4 
//		clock.ready();
//		assertEquals("2020-12-15",clock.set(2020, 12, 15)); // Legal 6
//		
//			
//		//Testing boundaries for time
////--------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(25, 0, 0)); //hour
////--------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(-1, 0, 0)); //hour
////--------------------------------------------------------------------		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(0, 61, 0)); //minute
////-------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(0, -24, 0));//minute
////-------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(0, 0, 64)); //second
////------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(0, 0, -10));//second
////-------------------------------------------------------------------
//		
//		//Testing boundaries for Date
////-------------------------------------------------------------------
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(1998, 1, 1));// Year
//		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(2198, 1, 1));// Year
//		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(2000, 14, 1));// Month
//		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(2000, -1, 1));// Month
//		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(2000, 1, 35)); // Day
//		
//		clock = new Clock();
//		clock.ready();
//		assertEquals("Out of bounds", clock.set(2000, 1, -12));// Day
//		
//	}
}
