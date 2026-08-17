DROP PROCEDURE IF EXISTS public.update_users_login(
    integer,
    boolean,
    integer,
    text,
    timestamp with time zone,
    timestamp with time zone
);

CREATE OR REPLACE PROCEDURE public.update_users_login(
    IN p_id integer,
    IN p_asset boolean,
    IN p_update_id integer,
    IN p_update_user text,
    IN p_update_date timestamp with time zone,
    IN p_verified_date timestamp with time zone
)
LANGUAGE plpgsql
AS $procedure$
BEGIN
    UPDATE public.user_login
    SET asset = p_asset,
        updated_id = p_update_id,
        updated_user = p_update_user,
        updated_date = p_update_date,
        verified_date = p_verified_date
    WHERE id = p_id;
END;
$procedure$;