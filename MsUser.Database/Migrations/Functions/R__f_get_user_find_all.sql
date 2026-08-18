-- Eliminar la función si ya existe
DROP FUNCTION IF EXISTS public.get_user_pagination(
    VARCHAR,
    INTEGER,
    INTEGER,
    VARCHAR,
    VARCHAR
);

-- Crear la función de paginación
CREATE OR REPLACE FUNCTION public.get_user_pagination(
    pi_name          VARCHAR,      -- Filtro por nombre (parcial)
    p_page_index     INTEGER,      -- Número de página (empieza en 1)
    p_page_size      INTEGER,      -- Cantidad de registros por página
    p_sort_column    VARCHAR,      -- Columna por la que ordenar
    p_sort_direction VARCHAR       -- 'ASC' o 'DESC'
)
RETURNS TABLE
(
    id           INT,
    name         VARCHAR(400),
    mail         VARCHAR(400),
    password     VARCHAR(500),
    asset        BOOLEAN,
    state        INT,
    created_id   INT,
    created_user VARCHAR(300),
    created_date TIMESTAMPTZ,
    updated_id   INT,
    updated_user VARCHAR(300),
    updated_date TIMESTAMPTZ,
    totalRows    INTEGER
)
LANGUAGE plpgsql
AS $$
DECLARE
    sortAsc  CONSTANT VARCHAR(4) := 'ASC';
    sortDesc CONSTANT VARCHAR(4) := 'DESC';
BEGIN
    RETURN QUERY
    WITH tempResult AS (
        SELECT
            ROW_NUMBER() OVER (
                ORDER BY
                    CASE WHEN p_sort_column = 'Name' AND p_sort_direction = sortAsc THEN u.name END ASC,
                    CASE WHEN p_sort_column = 'Name' AND p_sort_direction = sortDesc THEN u.name END DESC,
            
                    CASE WHEN p_sort_column = 'Mail' AND p_sort_direction = sortAsc THEN u.mail END ASC,
                    CASE WHEN p_sort_column = 'Mail' AND p_sort_direction = sortDesc THEN u.mail END DESC,
            
                    CASE WHEN p_sort_column = 'Asset' AND p_sort_direction = sortAsc THEN u.asset::text END ASC,
                    CASE WHEN p_sort_column = 'Asset' AND p_sort_direction = sortDesc THEN u.asset::text END DESC,
            
                    CASE WHEN p_sort_column = 'State' AND p_sort_direction = sortAsc THEN u.state END ASC,
                    CASE WHEN p_sort_column = 'State' AND p_sort_direction = sortDesc THEN u.state END DESC,
            
                    CASE WHEN p_sort_column = 'CreatedDate' AND p_sort_direction = sortAsc THEN u.created_date END ASC,
                    CASE WHEN p_sort_column = 'CreatedDate' AND p_sort_direction = sortDesc THEN u.created_date END DESC,
            
                    u.name ASC
            ) AS sequence_id,
            u.id,
            u.name,
            u.mail,
            u.password,
            u.asset,
            u.state,
            u.created_id,
            u.created_user,
            u.created_date,
            u.updated_id,
            u.updated_user,
            u.updated_date
        FROM public.user_login u
        WHERE (pi_name IS NULL OR u.name ILIKE '%' || pi_name || '%')
          AND u.state = 1  -- Solo usuarios activos
    ),
    tempCount AS (
        SELECT COUNT(*)::INT AS totalResults
        FROM tempResult
    )
    SELECT
        t.id,
        t.name,
        t.mail,
        t.password,
        t.asset,
        t.state,
        t.created_id,
        t.created_user,
        t.created_date,
        t.updated_id,
        t.updated_user,
        t.updated_date,
        tc.totalResults AS totalRows
    FROM tempResult t
    CROSS JOIN tempCount tc
    ORDER BY sequence_id
    OFFSET GREATEST(p_page_index - 1, 0) * p_page_size
    LIMIT p_page_size;
END;
$$;