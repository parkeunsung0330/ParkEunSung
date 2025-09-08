DROP PROCEDURE IF EXISTS `sp_select_characterbyuno`;

DELIMITER $$

CREATE PROCEDURE `sp_select_characterbyuno`(
_UNO INT 
)
BEGIN

	SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	SELECT `cno`,`user_uno`,`cname`,`ctribe`,`clv`,`cgender`,`cclass`,`str`,`dex`,`wisd`,`hp`,`mana`
	FROM `character`
    WHERE `user_uno` = _UNO;

    
    SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
END$$

DELIMITER ;