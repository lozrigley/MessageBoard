# MessageBoard

Brief: Please write a production ready dotnet core application that works like a simple message board. This app should expose a REST interface that allows an anonymous user to submit messages and to retrieve a list of the submitted messages. Please follow sound engineering practices and due to the limited time available, please document any trade-offs that you had to make whilst building this app.

# My Notes
The hour (nearer two in the end) went very fast.

Only added two methods, in reality I would guess you would want more with maybe a conversation id for example.

Depending on load. Maybe Microservices with a message queue would be better? Anyway I went for a DBaaS and containerized the solution for easy deployment and scalability although I had no time to test this in K8.

Added Swagger document but not really fleshed out the meta data.

Only Unit tested the very basic validation in the Domain. For production Inegrationn Tests would be required.

Wasnt able to fully check the config. For example have seperate Dev and Prod.

Would want better error handling. Just return a 500 for errors (400 if bad request)

Added some error checking Middleware at the end. Would want to flesh this out with proper error codes. Need to catch errors in code and throw more verbose errors to relay to end user.

Did not do add any encoding of strings. Like HTML encoding to check for injected Javascript or something. I feel this should really be job of consumer of API if it intends to display on web page. And ran out of time any way.

Think perhaps I should have just mocked the DAL. But wasn't sure as instuctions said "Production ready" If I were really given this as a task then a quick conversation with the Product Owner would have been best.

I would imagine a refactor is on the cards. But would need more idea of where API requirements are going to know how to do that. Nows its just about an MVP. With polishing needed of course

And also would use AutoMapper and probably AutoFac for DI because I like using Modules