IF NOT EXISTS(SELECT TOP 1 1 from Proposals where ProposalName ='ProposalName1')
BEGIN
INSERT INTO [dbo].[Proposals]
           ([Id]
           ,[ProposalName]
           ,[CustomerGrpName]
           ,[Date]
           ,[Description]
           ,[Status]
           ,[CreatedBy]
           ,[DateCreated]
           ,[DateModified]
           ,[ModifiedBy]
           ,[IsDeleted]
           ,[DateDeleted]
           ,[DeletedBy])
     VALUES
           ((SELECT NEWID())
           ,'ProposalName1'
           ,'CustomerGrpName1'
           ,GETUTCDATE()
           ,'Description1'
           ,'In Support'
           ,'Test User'
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,'Test User'
           ,0
           ,null
           ,null)
           END

           IF NOT EXISTS(SELECT TOP 1 1 from Proposals where ProposalName ='ProposalName2')
           BEGIN
           INSERT INTO [dbo].[Proposals]
           ([Id]
           ,[ProposalName]
           ,[CustomerGrpName]
           ,[Date]
           ,[Description]
           ,[Status]
           ,[CreatedBy]
           ,[DateCreated]
           ,[DateModified]
           ,[ModifiedBy]
           ,[IsDeleted]
           ,[DateDeleted]
           ,[DeletedBy])
     VALUES
           ((SELECT NEWID())
           ,'ProposalName2'
           ,'CustomerGrpName2'
           ,GETUTCDATE()
           ,'Description2'
           ,'In Support'
           ,'Test User'
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,'Test User'
           ,0
           ,null
           ,null)
           END
           IF NOT EXISTS(SELECT TOP 1 1 from Facilities where FacilityName ='FacilityName1')
           BEGIN
           INSERT INTO [dbo].[Facilities]
           ([Id]
           ,[ProposalId]
           ,[FacilityName]
           ,[BookingCountry]
           ,[Currency]
           ,[StartDate]
           ,[MaturityDate]
           ,[Limit]
           ,[CreatedBy]
           ,[DateCreated]
           ,[DateModified]
           ,[ModifiedBy]
           ,[IsDeleted]
           ,[DateDeleted]
           ,[DeletedBy])
     VALUES
           ((Select NEWID())
           ,'0F57B7A3-CB41-449E-A33C-36F8D1BF0F43'
           ,'FacilityName1'
           ,'Australia'
           ,'AUD'
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,225.00
           ,'Test User'
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,'Test User'
           ,0
           ,null
           ,null)
           END