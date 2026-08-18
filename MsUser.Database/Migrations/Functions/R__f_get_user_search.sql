CREATE OR REPLACE FUNCTION public.get_user_search(pi_id integer, pi_name character varying, pi_mail character varying, pi_asset boolean, pi_state integer)
 RETURNS TABLE(id integer, name character varying, mail character varying, password character varying, asset boolean, state integer, created_id integer, created_user character varying, created_date timestamp with time zone, updated_id integer, updated_user character varying, updated_date timestamp with time zone)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
    SELECT
        db.id,
        db.name,
        db.mail,
        db.password,
        db.asset,
        db.state,
        db.created_id,
        db.created_user,
        db.created_date,
        db.updated_id,
        db.updated_user,
        db.updated_date
    FROM public.user_login AS db
    WHERE (pi_id IS NULL OR pi_id = 0 OR db.id = pi_id)
      AND (pi_name IS NULL OR pi_name = '' OR db.name ILIKE '%' || pi_name || '%')
      AND (pi_mail IS NULL OR pi_mail = '' OR db.mail ILIKE '%' || pi_mail || '%')
	  AND (pi_asset IS NULL OR db.asset = pi_asset)
  	  AND (pi_state IS NULL OR db.state = pi_state)
    ORDER BY db.name ASC;
END;
$function$;