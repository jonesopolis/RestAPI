USE [Golf]
GO

declare @CourseId bigint;

insert into [dbo].[Courses]
           ([Name]
           ,[ImagePath])
     values
           ('Valley View Golf Club'
           ,'ValleyView')

set @CourseId = SCOPE_IDENTITY()

insert into [dbo].[CourseAddresses]
           ([CourseId]
           ,[Street]
           ,[City]
           ,[State]
           ,[Zip])
     values
           (@CourseId
           ,'3748 Lawrence Banet Rd'
           ,'Floyds Knobs'
           ,'IN'
           ,47119)

insert into [dbo].[CourseContactInfo]
           ([CourseId]
           ,[Website]
           ,[ContactEmail]
           ,[ContactPhone])
	values
           (@CourseId
           ,'www.ValleyViewGolfClub.org'
           ,'carol@valleyviewgolfclub.org'
           ,'812-923-9280')

insert into [dbo].[CourseTexts]
           ([CourseId]
           ,[About])
     values
           (@CourseId
           ,'Valley View Golf Club is nestled in the beautiful hills of Floyds Knobs, Indiana. Just west of New Albany, Indiana. Valley View is located at 1-64 and State Road 150 north. Valley View Golf Club is just 10 minutes away from downtown Louisville, Kentucky and is a beautiful public golf venue, offering many challenges to the novice and expert golfer alike! The only 18-holw public course in Floyd County, this 6,910 yard, par 72 track has a variety of holes and challenges and is open year-round (weather permitting).
			 Favorite holes include #3, a formidable par 5 that doglegs left and crosses the Little Indian creek to a green nestled in the hillside. Valley View golf couse offers four par 3’s, two of which are over 200 yards. There are four par 5’s, two on the front 9 holes and two on the back. The front nine, harder of the two nines, is very unassuming and plays harder then it looks. The back nine holes offer the golfer a chance for redemption with two reachable par 5’s. 
			 Beware! The uneven lines and out of bounds are always lurking and waiting for just one bad swing. The huge greens on the back nine welcomes even the less than perfect shot giving the golfer a false sense of accomplishment only to find the undulations of the greens to be a formidable challenge.
			 All in all, the golf experience you’ll find at Valley View Golf Club is very satisfying and a must-play for any discriminating golfer. Come experience what a pleasure it is to play “The View”.')

--insert into [dbo].[Hole]
--			([CourseId]
--			,[Number]
--			,[Par]
--			,[WistiaKey])
--	  values
--			(@CourseId, 1, 5, '')




