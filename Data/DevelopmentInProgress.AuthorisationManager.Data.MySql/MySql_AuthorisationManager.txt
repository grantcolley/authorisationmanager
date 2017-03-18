-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema AuthorisationManager
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema AuthorisationManager
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AuthorisationManager` ;
USE `AuthorisationManager` ;

-- -----------------------------------------------------
-- Table `AuthorisationManager`.`Activity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`Activity` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` NVARCHAR(50) NOT NULL,
  `ActivityCode` NVARCHAR(50) NOT NULL,
  `Description` NVARCHAR(100) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`Role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`Role` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` NVARCHAR(50) NOT NULL,
  `RoleCode` NVARCHAR(50) NOT NULL,
  `Description` NVARCHAR(100) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`UserAuthorisation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`UserAuthorisation` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `UserName` NVARCHAR(100) NOT NULL,
  `DisplayName` NVARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`ActivityActivity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`ActivityActivity` (
  `ParentActivityId` INT NOT NULL,
  `ActivityId` VARCHAR(45) NOT NULL,
  UNIQUE INDEX `IXActivityActivity` (`ParentActivityId` ASC, `ActivityId` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`RoleActivity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`RoleActivity` (
  `RoleId` INT NOT NULL,
  `ActivityId` INT NOT NULL,
  UNIQUE INDEX `IXRoleActivity` (`RoleId` ASC, `ActivityId` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`RoleRole`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`RoleRole` (
  `ParentRoleId` INT NOT NULL,
  `RoleId` VARCHAR(45) NOT NULL,
  UNIQUE INDEX `IXRoleRole` (`ParentRoleId` ASC, `RoleId` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AuthorisationManager`.`UserRole`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AuthorisationManager`.`UserRole` (
  `Id` INT NOT NULL,
  `RoleId` INT NOT NULL,
  UNIQUE INDEX `IXUserRole` (`Id` ASC, `RoleId` ASC))
ENGINE = InnoDB;

CREATE USER 'authmanager' IDENTIFIED BY 'authmanager123';

GRANT ALL ON `AuthorisationManager`.* TO 'authmanager';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
