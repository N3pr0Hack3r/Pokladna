CREATE PROCEDURE dbo.spOpravaZaznamu    
AS
BEGIN
 declare @aktRadek int
 declare @IdPokladniZaznam int
 declare @Datum datetime
 declare @CisloPolozky int
 declare @Zustatek float
 declare @t table (
  [Index] int primary key,
  IdPoklZaznam int,
  Datum datetime,
  Cislo int,
  Zustatek float
 )

 if exists (select * from PokladniZaznamy) 
  begin
   insert into @t select [Index]=ROW_NUMBER() over (order by Datum),IdPokladniZaznam,Datum, Cislo, Zustatek from PokladniZaznamy   
   --select * from @t 
   
   select top 1 @aktRadek=[Index],@IdPokladniZaznam=IdPoklZaznam,@Datum=Datum, @CisloPolozky=Cislo, @Zustatek=Zustatek from @t order by [Index]

   while @aktRadek is not null
    begin
     if @aktRadek = 1
      begin
       update PokladniZaznamy set Cislo=1, Zustatek=Castka, @Zustatek=Castka where IdPokladniZaznam=@IdPokladniZaznam
       select @CisloPolozky=1       
      end
     else
      begin
       update PokladniZaznamy 
       set 
          Cislo=case 
                  when MONTH(@datum)=MONTH(Datum) then @CisloPolozky+1
                  else 1
                end
         ,Zustatek=@Zustatek+Castka 
       where IdPokladniZaznam=@IdPokladniZaznam
       
       select @Zustatek=zustatek,@CisloPolozky=Cislo, @Datum=Datum from PokladniZaznamy where IdPokladniZaznam=@IdPokladniZaznam       
      end
     select @aktRadek=min([index]) from @t where [Index]>@aktRadek
     select @IdPokladniZaznam=IdPoklZaznam from @t where [Index]=@aktRadek
    end
  end
 
END
