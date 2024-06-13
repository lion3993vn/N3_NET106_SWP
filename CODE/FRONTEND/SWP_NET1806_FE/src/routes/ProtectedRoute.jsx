import React from 'react';
import { Navigate, Route } from 'react-router-dom';
import { useAuth } from './context/AuthContext';

const ProtectedRoute = ({ element: Component, roles, ...rest }) => {
  const { user } = useAuth();

  if (!user) {
    return <Navigate to="/login" />;
  }


  if (roles && !roles.includes(user.role)) {
    return <Navigate to="/403" />;
  }

  return <Route {...rest} element={<Component />} />;
};

export default ProtectedRoute;
