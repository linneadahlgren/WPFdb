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


	// S1 below
	//________________________________________________________________________		

	@Test
	void testDisplayTimeToDisplayDate() { 								// DISPLAY_TIME--> DISPLAY_DATE - (CM)
		assertEquals("2000-1-1", clock.changeMode()); 					
	}

	@Test
	void testDisplayTimeToChangeTime() { 								// DISPLAY_TIME --> CHANGE_TIME - (R)
		assertEquals("0:0:0",clock.ready()); 							
	}

	@Test
	void testUsingSetInDisplayTime() {  								// Trying to run method set in state DISPLAY_TIME - Illegal (S)
		assertEquals(clock.illegal, clock.set(0,0,0)); 					
	}

	// S2 below
	//________________________________________________________________________	
	@Test
	void testDisplayDateToDisplayTime() {   							// DISPLAY_DATE--> DISPLAY_TIME - (CM)
		clock.changeMode();
		assertEquals("0:0:0", clock.changeMode()); 						
	}
	@Test
	void testDisplayDateToChangeDate() {		 						// DISPLAY_DATE--> CHANGE_DATE - (R)
		clock.changeMode();
		assertEquals("2000-1-1",clock.ready()); 						
	}
	@Test
	void testUsingSetInDisplayDate() { 									// Running method set in state DISPLAY_TIME - Illegal (S)
		clock.changeMode();
		assertEquals(clock.illegal, clock.set(0,0,0)); 					
	}
	// S3 below
	//________________________________________________________________________	
	@Test
	void testChangeTimeToDisplayTime() { 								// CHANGE_TIME --> DISPLAY_TIME (S)
		clock.ready();
		assertEquals("10:47:30", clock.set(10, 47, 30));  
	}
	@Test
	void testUsingReadyInChangeTime() {									// Running method ready in state CHANGE_TIME - Illegal (R) 
		clock.ready();
		assertEquals(clock.illegal, clock.ready());
	}
	@Test
	void testUsingChangeModeInChangeTime() { 							// Running method changeMode in state CHANGE_TIME - Illegal (CM)
		clock.ready();
		assertEquals(clock.illegal, clock.changeMode());
	}
	// S4 below
	//________________________________________________________________________	
	@Test 
	void testChangeDateToDisplayDate() {								// CHANGE_DATE --> DISPLAY_DATE (S)
		clock.changeMode();
		clock.ready();
		assertEquals("2020-12-15",clock.set(2020, 12, 15));  
	}
	@Test	
	void testUsingReadyInChangeDate() {									//Running method ready in state CHANGE_DATE - Illegal (R) 
		clock.changeMode();
		clock.ready();
		assertEquals(clock.illegal, clock.ready());
	}
	@Test
	void testUsingChangeModeInChangeDate() {							// Running method changeMode in state CHANGE_DATE - Illegal (CM)
		clock.changeMode();
		clock.ready();
		assertEquals(clock.illegal, clock.changeMode());
	}


	//--------------------------Testing boundaries for time------------------------

	@Test
	void testHourUpperBounds() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(24, 0, 0)); 			// Hour is above the boundaries for hours
	} 

	@Test
	void testHourLowerBoundsException() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(-1, 0, 0));			// Hour is below boundaries for hours
	}

	@Test
	void testMinutesUpperBoundary() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(0, 61, 0)); 			// Minute is above the boundaries for minutes
	}

	@Test
	void testMinutesLowerBounds() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(0, -24, 0));			// Minute is below boundaries for minutes

	}

	@Test
	void testSecondsUpperBounds() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(0, 0, 60)); 			// second is above the boundaries for seconds
	}

	@Test
	void testSecondsLowerBounds() {
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(0, 0, -1));			// Second is below boundaries for seconds
	}


	////--------------------Testing boundaries for Date-----------------------------------------------
	
	@Test
	void testYearInBounds() {
		clock.changeMode();
		clock.ready();
		
		assertEquals("2020-12-17", clock.set(2020, 12, 17)); 			// Year is below the boundaries for year
	}	
	@Test
	void testYearLowerBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(1999, 1, 1));			// Year is below the boundaries for year
	}	  

	@Test
	void testYearUpperBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(2101, 1, 1));			// Year is above the boundaries for year

	}

	@Test 	
	void testMonthUpperBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(2000, 13, 1));		// Month is above boundary for month
	}
 
	@Test
	void testMonthsLowerBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(2000, -1, 1));		// Month is below boundaries for month
	}

	@Test 
	void testDaysUpperBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(2000, 1, 32)); 		// Day is above top boundary for days

	}

	@Test
	void testDaysLowerBounds() {
		clock.changeMode();
		clock.ready();
		assertEquals(clock.outOfBounds, clock.set(2000, 1, -1));		// Day is below boundaries for day

	}

}
