package clock;





public class Clock {
	
	private Time theTime = new Time(); 
	private Date theDate = new Date() ; 
	
	enum State{
		DISPLAY_TIME,
		DISPLAY_DATE,
		CHANGE_TIME,
		CHANGE_DATE,
	}
	private State currentState = State.DISPLAY_TIME; 

	public final String  illegal = "Illegal transition";
	public final String outOfBounds = "Out of bounds";
	
	public String changeMode() {
		switch(this.currentState) {

		case DISPLAY_TIME:
			currentState = State.DISPLAY_DATE;
			return theDate.showDate();

		case DISPLAY_DATE: 
			currentState = State.DISPLAY_TIME;
			return theTime.showTime();

		default: return illegal;
		
		}
	}
	public String ready() {
		switch(this.currentState) {

		case DISPLAY_TIME: 
			currentState = State.CHANGE_TIME;
			return theTime.showTime();
		case DISPLAY_DATE: 
			currentState = State.CHANGE_DATE;
			return theDate.showDate();

		default: return illegal; 

		}	
	}
	public String set(int p1, int p2, int p3) { 
		switch(this.currentState) {

		case CHANGE_TIME: 
			currentState = State.DISPLAY_TIME;
			return theTime.timeSet(p1, p2, p3);
		
		case CHANGE_DATE: 
			currentState = State.DISPLAY_DATE;
			return theDate.dateSet(p1, p2, p3);

		default: return illegal;
		
		}

	}

}
