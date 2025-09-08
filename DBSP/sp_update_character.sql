DROP PROCEDURE IF EXISTS `sp_update_character`;

DELIMITER $$

CREATE PROCEDURE `sp_update_character`(
_CNO INT,
_CNAME VARCHAR(45),
_CTRIBE VARCHAR(45),
_CLV INT,
_CGENDER TINYINT,
_CCLASS VARCHAR(45),
_STR INT,
_DEX INT,
_WISD INT,
_HP INT,
_MANA INT
)
BEGIN
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @errstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @errtext = MESSAGE_TEXT;
        SET @errstmt := "INSERT INTO `ErrorProcedure`(`errLocate`,`errNum`,`errCode`,`errMsg`) VALUES('sp_update_character',?,?,?)";
        PREPARE stmt FROM @errstmt;
        EXECUTE stmt USING @errno,@errstate,@errtext;
        DEALLOCATE PREPARE stmt;
        ROLLBACK;
        SET @_errcode = "E0500";
	END;
    
    
    
	SET @_errcode = "E0000";
    
		START TRANSACTION;
			SET @stmt := "UPDATE `character`SET `cname` = ?,`ctribe` = ?,`clv` = ?,`cgender` = ?,`cclass` = ?,`str` = ?,`dex` = ?,`wisd` = ?,`hp` = ?,`mana` = ?,`uptdate` = current_timestamp() WHERE `cno` = ?";
			PREPARE stmt FROM @stmt;
			SET @a := _CNAME, @b := _CTRIBE, @c :=_CLV, @d :=_CGENDER, @e :=_CCLASS, @f :=_STR, @g :=_DEX, @h :=_WISD, @i :=_HP, @j :=_MANA, @k=_CNO;
			EXECUTE stmt USING @a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k;
			DEALLOCATE PREPARE stmt;
		COMMIT;
 
        SELECT @_errcode AS `errorcode`;


END$$



