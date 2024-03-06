BEGIN TRANSACTION;

ALTER TABLE "User" ADD "PasswordHash" BLOB NULL;

ALTER TABLE "User" ADD "PasswordSalt" BLOB NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240306201854_UserPasswordAdded', '7.0.16');

COMMIT;

