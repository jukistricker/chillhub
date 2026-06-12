CREATE OR REPLACE PROCEDURE chillhub_db.refresh_dashboard_snapshot()
LANGUAGE plpgsql
AS $$
DECLARE
    v_users INT;
    v_roles INT;
    v_permissions INT;
    v_permission_groups INT;
    v_medias INT;
BEGIN

    SELECT COUNT(*) INTO v_users FROM users;
    SELECT COUNT(*) INTO v_roles FROM roles;
    SELECT COUNT(*) INTO v_permissions FROM permissions;
    SELECT COUNT(*) INTO v_permission_groups FROM permission_groups;
    SELECT COUNT(*) INTO v_medias FROM medias;

    INSERT INTO dashboard (
        users_count,
        roles_count,
        permissions_count,
        permission_groups_count,
        medias_count,
        created_at
    )
    VALUES (
        v_users,
        v_roles,
        v_permissions,
        v_permission_groups,
        v_medias,
        NOW()  
    );

END;
$$;