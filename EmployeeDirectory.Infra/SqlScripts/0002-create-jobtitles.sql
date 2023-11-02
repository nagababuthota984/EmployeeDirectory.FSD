-- Table: public.JobTitles

-- DROP TABLE IF EXISTS public."JobTitles";

CREATE TABLE IF NOT EXISTS public."JobTitles"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Title" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "CreatedBy" text COLLATE pg_catalog."default" NOT NULL,
    "ModifiedOn" timestamp with time zone NOT NULL,
    "ModifiedBy" text COLLATE pg_catalog."default" NOT NULL,
    "IsDeleted" boolean NOT NULL,
    CONSTRAINT "PK_JobTitles" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."JobTitles"
    OWNER to postgres;