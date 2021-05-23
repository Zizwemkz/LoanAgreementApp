



Create Table dbo.InterestAgreementType
(
AgreementTypeID int
, AgreementName nvarchar (max)

)


insert into [dbo].[InterestAgreementType] (AgreementTypeID, AgreementName)

values (1, 'Mortgage agreements')
,(2, 'Credit facilities')
,(3, 'Unsecured credit transactions')
,(4, 'Developmental credit agreements For development of a small business')
,(5, 'Developmental credit agreements For low income housing (unsecured)')
,(6, 'Short term credit transactions')
,(7, 'Other credit agreements')
,(8, 'Incidental credit agreements')


select * from [dbo].[InterestAgreementType] 