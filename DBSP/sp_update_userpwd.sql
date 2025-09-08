DROP PROCEDURE IF EXISTS `sp_delete_user`;

DELIMITER $$

CREATE PROCEDURE `sp_delete_user`(
_UNO INT
)
BEGIN
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @errstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @errtext = MESSAGE_TEXT;
        SET @errstmt := "INSERT INTO `ErrorProcedure`(`errLocate`,`errNum`,`errCode`,`errMsg`) VALUES('sp_delete_user',?,?,?)";
        PREPARE stmt FROM @errstmt;
        EXECUTE stmt USING @errno,@errstate,@errtext;
        DEALLOCATE PREPARE stmt;
        ROLLBACK;
        SET @_errcode = "E0500";
	END;
    
    SET @_errcode = "E0000";

	START TRANSACTION;
		SET @stmt := "DELETE FORM `user` WHERE `uno` = ?";      
		PREPARE stmt FROM @stmt;
		SET @a := _UNO;
		EXECUTE stmt USING @a;
		DEALLOCATE PREPARE stmt;
	COMMIT;
    
    SELECT @_errcode AS `errorcode`;

END$$

DELIMITER ;