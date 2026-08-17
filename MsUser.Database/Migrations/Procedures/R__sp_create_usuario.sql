CREATE OR REPLACE PROCEDURE public.create_user_login(
    p_name          text,
    p_mail          text,
    p_password      text,
    p_asset         boolean,
    p_state         integer,
    p_created_id    integer,
    p_created_user  text,
    p_created_date  timestamptz,
    p_verified_date timestamptz
)
LANGUAGE plpgsql
AS $BODY$
BEGIN
    INSERT INTO public.user_login (
        name,
        mail,
        password,
        asset,
        state,
        created_id,
        created_user,
        created_date,
        verified_date
    ) VALUES (
        p_name,
        p_mail,
        p_password,
        p_asset,
        p_state,
        p_created_id,
        p_created_user,
        p_created_date,
        p_verified_date
    );
END;
$BODY$;