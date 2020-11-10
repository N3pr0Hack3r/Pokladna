CREATE PROCEDURE [dbo].spOpravaZaznamu
AS
begin
declare @CisloPolozky int
declare @Zustatek float
declare @aktRadek int
declare @IDPokladniZaznam int
declare @Datum datetime
declare @t table
(
[index] int primary key,
IdPokladniZaznam int,
Datum datetime,
Cislo int,
Zustatek float
)

if exists (select * from pokladnizaznamSima) 
	begin
insert into @t select [index]=ROW_NUMBER() over (order by Datum),IdPokladniZaznam,Datum ,Cislo, Zustatek from pokladnizaznamSima
	select top 1 @aktRadek = [index],@IDPokladniZaznam = IdPokladniZaznam ,@Datum = Datum ,@CisloPolozky = Cislo, @Zustatek=Zustatek from @t order by [index]
	--UwU

	
	while @aktRadek is not null
		begin
		if @aktRadek = 1
			begin
			update Pokladnizaznam set Cisclo=1, Zustatek = Castka where IdPokladniZaznam = @IDPokladniZaznam
			set @CisloPolozky = 1
			end
			else
			begin
			update Pokladnizaznam set Cisclo=@CisloPolozky+1,Zustatek=@Zustatek+Castka,@CisloPolozky = @CisloPolozky +1,@Zustatek=@Zustatek+Castka where IdPokladniZaznam=@IDPokladniZaznam
			end
			select @aktRadek = min([index]) from @t where [index]>@aktRadek
			select @IDPokladniZaznam = IdPokladniZaznam, @Datum = Datum from @t where [index] = @aktRadek
		end
	end
END

