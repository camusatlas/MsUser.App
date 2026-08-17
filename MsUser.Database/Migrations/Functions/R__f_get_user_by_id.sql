CREATE OR REPLACE FUNCTION public.get_user_by_id(
    p_id integer
)
RETURNS TABLE
(
    id int,
    name varchar,
    mail varchar,
    asset boolean,
    state int
)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY
    SELECT
        u.id,
        u.name,
        u.mail,
        u.asset,
        u.state
    FROM public.user_login u
    WHERE u.id = p_id;
END;
$$;