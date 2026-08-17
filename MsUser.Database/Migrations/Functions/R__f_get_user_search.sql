DROP FUNCTION IF EXISTS public.get_user_search(INT, VARCHAR, VARCHAR, BOOLEAN, INT);

CREATE OR REPLACE FUNCTION public.get_user_search(
    pi_id INT,
    pi_name VARCHAR,
    pi_mail VARCHAR,
    pi_asset BOOLEAN,
    pi_state INT
)
RETURNS TABLE
(
    id INT,
    name VARCHAR(400),
    mail VARCHAR(400),
    password VARCHAR(500),
    asset BOOLEAN,
    state INT,
    created_id INT,
    created_user VARCHAR(300),
    created_date TIMESTAMPTZ,
    updated_id INT,
    updated_user VARCHAR(300),
    updated_date TIMESTAMPTZ
)
LANGUAGE plpgsql
AS $BODY$
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
    ORDER BY db.name ASC;
END;
$BODY$;