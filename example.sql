use byteshark;

if((select saldo from users where id=2)>0) BEGIN
	UPDATE users set saldo-=100 where id=2
END
--UPDATE users set saldo=100 where id=1
SELECT * FROM users