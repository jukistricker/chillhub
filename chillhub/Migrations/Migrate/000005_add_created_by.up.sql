DO $$ 
DECLARE
r RECORD;
    v_admin_id UUID;
BEGIN
    -- 1. Lấy ID của user 'admin' từ bảng users
    -- Giả định bảng của bạn tên là 'users' và cột username tên là 'username'
SELECT id INTO v_admin_id
FROM users
WHERE username = 'admin'
    LIMIT 1;

-- Kiểm tra nếu không tìm thấy admin thì báo lỗi và dừng lại
IF v_admin_id IS NULL THEN
        RAISE EXCEPTION 'Không tìm thấy tài khoản có username là admin. Vui lòng kiểm tra lại!';
END IF;

    RAISE NOTICE 'Bắt đầu cập nhật với Admin ID: %', v_admin_id;

    -- 2. Lặp qua tất cả các bảng có cột created_by hoặc updated_by
FOR r IN
SELECT table_schema, table_name, column_name
FROM information_schema.columns
WHERE column_name IN ('created_by', 'updated_by')
  AND table_schema = 'public'
  -- Loại trừ bảng users để tránh việc update chính nó nếu không cần thiết
  -- AND table_name <> 'users' 
    LOOP
        -- 3. Thực thi SQL động
        EXECUTE format('UPDATE %I.%I SET %I = %L WHERE %I IS NULL', 
            r.table_schema, r.table_name, r.column_name, v_admin_id, r.column_name);

RAISE NOTICE 'Đã xử lý bảng: %.% cột: %', r.table_schema, r.table_name, r.column_name;
END LOOP;
    
    RAISE NOTICE 'Hoàn thành dọn dẹp dữ liệu NULL.';
END $$;