create table tbl_articles(ArtcId INT auto_increment primary key,ArtcName LONGTEXT,ArtcCode VARCHAR(20),Artctype INT, Price DECIMAL(16,3), `Status` INT);
create table tbl_articlestype(ArtctypeId INT auto_increment primary key,ArtctypeName VARCHAR(100));

DELIMITER ;;
CREATE PROCEDURE sp_insupd_article(_id INT,_name LONGTEXT,_code VARCHAR(20),_type INT,_price DECIMAL(16,3),_status INT)
BEGIN
IF(_id=0)
THEN
BEGIN
INSERT INTO tbl_articles(ArtcName,ArtcCode,Artctype, Price,`Status`) VALUES(_name,_code,_type,_price,_status);
END ;
ELSE
BEGIN
UPDATE tbl_articles SET
ArtcName=_name,
ArtcCode=_code,
Artctype=_type,
Price=_price,
`Status`=_status 
WHERE ArtcId = _id ;
END ;
END IF;
END ;;
DELIMITER ;

CREATE VIEW vw_tbl_articles AS SELECT A.*,T.ArtctypeName FROM tbl_articles AS A
LEFT JOIN tbl_articlestype T ON A.Artctype=T.ArtctypeId ;

insert into tbl_articlestype values (1,'Grocery Food'),(2,'Grocery NonFood'),(3,'Stationary'),(4,'Textile') ;

select * from vw_tbl_articles
