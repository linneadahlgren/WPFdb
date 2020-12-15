package clock;

public class Time {
	private int theHour = 0;
	private int theMinute = 0;
	private int theSecond= 0;
	
	public final String outOfBounds = "Out of bounds";

	protected String timeSet(int hour, int minute, int second) {
			if( (hour >23 || hour <0) || (minute >59 || minute<0) || (second >59 || second <0)) {
				return outOfBounds;
			}
			this.theHour = hour;
			this.theMinute = minute;
			this.theSecond = second; 
		
		return theHour+":"+theMinute+":"+theSecond; 
	}
	protected String showTime() { 
		
		
		return theHour+":"+theMinute+":"+theSecond;
	}
}
