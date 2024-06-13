import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSquareCaretLeft, faSquareCaretRight, } from "@fortawesome/free-solid-svg-icons";
import "../../assets/css/styleblog.css";
import { useAuth } from "../../context/AuthContext";
import no_found from "../../assets/img/404.jpg";

const Blog = () => {
  const [blogs, setBlogs] = useState([]);
  const { user } = useAuth();
  const [paging, setPaging] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        if (paging.CurrentPage === undefined) {
          // Nếu đây là lần đầu fetch, đặt paging.CurrentPage là 1
          setPaging((prevState) => ({
            ...prevState,
            CurrentPage: 1,
          }));
          return;
        }

        const response = await fetch(
          `https://littlejoyapi.azurewebsites.net/api/blog?PageIndex=${paging.CurrentPage}&PageSize=9`
        );

        const paginationData = JSON.parse(response.headers.get('X-Pagination'));
        setPaging(paginationData);

        const previous = document.getElementById('blog-pre');
        const next = document.getElementById('blog-next');

        if (paging.CurrentPage === 1) {
          // Trang đầu tiên
          previous.style.opacity = '0.5'; // Mờ đi vì không có trang trước
          next.style.opacity = paginationData.TotalPages > 1 ? '1' : '0.5'; // Hiển thị nút "next" nếu có nhiều hơn một trang
        } else if (paging.CurrentPage === paginationData.TotalPages) {
          // Trang cuối cùng
          previous.style.opacity = '1'; // Hiển thị nút "previous"
          next.style.opacity = '0.5'; // Mờ đi vì không có trang sau
        } else {
          // Các trang ở giữa
          previous.style.opacity = '1'; // Hiển thị nút "previous"
          next.style.opacity = '1'; // Hiển thị nút "next"
        }

        const data = await response.json();
        const updatedData = data.map((blog) => {
          const dateParts = blog.date.split('T')[0].split('-');
          const formattedDate = `${dateParts[2]}/${dateParts[1]}/${dateParts[0]}`;

          return {
            ...blog,
            banner: blog.banner == null || blog.banner === '' ? no_found : blog.banner,
            date: formattedDate, // Chuyển đổi định dạng ngày
          };
        });
        setBlogs(updatedData);
      } catch (error) {
        console.error('Lỗi khi lấy dữ liệu blog:', error.message);
      }
    };

    fetchData();
  }, [paging.CurrentPage]);

  const handleDeleteBlog = (id) => {};

  const handlePrevious = () => {
    if (paging.CurrentPage > 1) {
      setPaging((prevState) => ({
        ...prevState,
        CurrentPage: prevState.CurrentPage - 1, // Giảm CurrentPage đi 1 khi nhấn Previous
      }));
    }
  };

  const handleNext = () => {
    if (paging.CurrentPage < paging.TotalPages) {
      setPaging((prevState) => ({
        ...prevState,
        CurrentPage: prevState.CurrentPage + 1,
      }));
    }
  };

  return (
    <>
      <div className="container-fluid ">
        <div className="row">
          <div className="col-md-12 banner py-5 text-center">
            <h1
              className="text-center"
              style={{
                color: "#3C75A6",
                fontWeight: "600",
                fontFamily: "sans-serif",
              }}
            >
              Blog
            </h1>
            <div className="d-inline-block">
              <div className="d-flex align-content-between">
                <p className="px-2">
                  <Link
                    to="/"
                    style={{ color: "#103A71", textDecoration: "none" }}
                  >
                    Home
                  </Link>
                </p>
                <p className="px-2">
                  <FontAwesomeIcon
                    icon="fa-solid fa-angles-right"
                    style={{ color: "#3c75a6" }}
                  />
                </p>
                <p className="px-2">
                  <Link
                    to="/blog"
                    style={{ color: "#103A71", textDecoration: "none" }}
                  >
                    Blog
                  </Link>
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="container-fluid body-content">
        <div className="container pt-5">
          <div className="row">
            <div className="col-md-12 mt-5 mb-5 d-flex justify-content-end">
              {user && user.role !== "USER" && (
                <Link
                  to="/createblog"
                  className="btn-create-blog d-inline-block px-4 py-2"
                  style={{
                    backgroundColor: "rgba(60, 117, 166, 1)",
                    color: "white",
                    borderRadius: "15px",
                    textDecoration: "none",
                  }}
                >
                  <span>Tạo mới</span>
                </Link>
              )}
            </div>
            {blogs.map((blog) => (
              <div key={blog.id} className="col-md-4 p-3">
                <div className="w-100" style={{ position: "relative" }}>
                  <Link
                    to={`/blogdetail/${blog.id}`}
                    className="w-100"
                    style={{ textDecoration: "none", color: "black" }}
                  >
                    <div
                      className="blog-content-main w-100 p-4"
                      style={{
                        backgroundColor: "#ededed",
                        borderRadius: "15px",
                      }}
                    >
                      <div className="blog-image">
                        <img
                          src={blog.banner}
                          alt=""
                          style={{
                            width: "100%",
                            height: "auto",
                            borderRadius: "15px",
                            aspectRatio: "2/1",
                            backgroundPosition: "center",
                            backgroundSize: "cover",
                            backgroundRepeat: "no-repeat",
                          }}
                        />
                      </div>

                      <div className="mt-3">
                        <span className="fs-5 fw-bold">{blog.title}</span>
                      </div>
                      <div className="blog-date mt-3 w-100 d-flex justify-content-end">
                        <span style={{ color: "#97999D" }}>{blog.date}</span>
                      </div>
                    </div>
                  </Link>
                  <div
                    className="delete-blog"
                    onClick={() => handleDeleteBlog(blog.id)}
                    style={{
                      position: "absolute",
                      top: "10px",
                      right: "10px",
                      cursor: "pointer",
                    }}
                  >
                    <FontAwesomeIcon icon="fa-solid fa-circle-xmark" />
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
      <div className="mt-3 mb-5 py-5" style={{ fontSize: "25px" }}>
        <div className="d-inline-block float-end">
          <div className="fs-5 px-5">
            <Link className="pe-2 fs-3" to="#" style={{ color: "#3C75A6" }}>
              <FontAwesomeIcon
                id="blog-pre"
                icon={faSquareCaretLeft}
                onClick={handlePrevious}
              />
            </Link>
            <span className="px-2 fs-4" style={{ fontFamily: "Roboto" }}>
              Trang {paging.CurrentPage}
            </span>
            <Link className="ps-2 fs-3" to="#" style={{ color: "#3C75A6" }}>
              <FontAwesomeIcon
                id="blog-next"
                icon={faSquareCaretRight}
                className="pe-3"
                onClick={handleNext}
              />
            </Link>
          </div>
        </div>
      </div>
    </>
  );
};

export default Blog;