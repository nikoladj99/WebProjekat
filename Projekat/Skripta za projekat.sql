
--SKRIPTA ZA BOLNICU - CREATE 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BolnicaPodaci](
	[IME] [nvarchar](max) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[M] [int] NOT NULL,
	[N] [int] NOT NULL,
 CONSTRAINT [PK_BolnicaPodaci] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[BolnicaPodaci] ADD  DEFAULT ((0)) FOR [M]
GO
ALTER TABLE [dbo].[BolnicaPodaci] ADD  DEFAULT ((0)) FOR [N]
GO


--SKRIPTA ZA BOLNICU - INSERT

set identity_insert [#tempBolnicaPodaci] on;


insert [#tempBolnicaPodaci] ([IME],[ID],[M],[N])
select 'Bolnica-Leskovac',9,6,5;

set identity_insert [#tempBolnicaPodaci] off;

--SKRIPTA ZA LEKARE - CREATE 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LekarPodaci](
	[IDLekara] [nvarchar](450) NOT NULL,
	[IME] [nvarchar](max) NULL,
	[PREZIME] [nvarchar](max) NULL,
	[SPECIJALIZACIJA] [nvarchar](max) NULL,
	[BolnicaID] [int] NULL,
 CONSTRAINT [PK_LekarPodaci] PRIMARY KEY CLUSTERED 
(
	[IDLekara] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_LekarPodaci_BolnicaID] ON [dbo].[LekarPodaci]
(
	[BolnicaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LekarPodaci]  WITH CHECK ADD  CONSTRAINT [FK_LekarPodaci_BolnicaPodaci_BolnicaID] FOREIGN KEY([BolnicaID])
REFERENCES [dbo].[BolnicaPodaci] ([ID])
GO
ALTER TABLE [dbo].[LekarPodaci] CHECK CONSTRAINT [FK_LekarPodaci_BolnicaPodaci_BolnicaID]
GO


-- SKRIPTA ZA LEKARE - INSERT 

--create table [#tempLekarPodaci] (
--[IDLekara] [nvarchar] (450),
--[IME] [nvarchar] (max) NULL,
--[PREZIME] [nvarchar] (max) NULL,
--[SPECIJALIZACIJA] [nvarchar] (max) NULL,
--[BolnicaID] [int] NULL);


insert [#tempLekarPodaci] ([IDLekara],[IME],[PREZIME],[SPECIJALIZACIJA],[BolnicaID])
select '1','Ana','Ivic','Hirurgija',9 UNION ALL
select '10','Aleksandar','Brkic','Infektivno',9 UNION ALL
select '11','Katarina','Cvetkovic','Infektivno',9 UNION ALL
select '12','Goran','Zlatkovic','Pedijatrija',9 UNION ALL
select '13','Nenad','Mitic','Oftalmologija',9 UNION ALL
select '14','Ivana','Boskovic','Ginekologija',9 UNION ALL
select '2','Milan','Ratkovic','Hirurgija',9 UNION ALL
select '3','Nikola','Stojanovic','Interno',9 UNION ALL
select '4','Darko','Djokic','Interno',9 UNION ALL
select '5','Marko','Mitrovic','Urologija',9 UNION ALL
select '6','Anastasija','Petkovic','Neurologija',9 UNION ALL
select '7','Tijana','Zaric','Neurologija',9 UNION ALL
select '8','Dejan','Ivanovic','Nefrologija',9 UNION ALL
select '9','Mateja','Lazic','Infektivno',9;