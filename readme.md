# Windows Time Automatic Update

If, like me, you have an ancient computer lying around which you power up every now and then, you may have come across the situation where the CMOS battery is completely dead.

In my situation, the battery is also not replaceable.  As a result, I'm stuck with a system which has a date set somewhere in 1999.

This little script simply gets the time from a server (located at www.portvisibility.co.uk ) over HTTP and sets the time on the machine at startup using the built in windows commands.
