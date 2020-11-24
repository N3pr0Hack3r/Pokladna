CREATE TRIGGER tr
	on [dbo].[PokladniZaznamy]
	for delete, insert, update
	as 
	begin
	set nocount on
	exec dbo.spOpravaZaznamu
	end