﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Taijitan.Controllers;
using Taijitan.Models.Domain;
using Taijitan.Models.UserViewModel;
using TaijitanTest.Data;
using Xunit;

namespace TaijitanTest.Controllers
{
    public class UserControllerTest
    {
        
        #region Fields
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly UserController _userController;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<ICityRepository> _mockCityRepository;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly User _tomJansens;
        private readonly int _tomJansensId;

    
        #endregion

        #region Constructors
        public UserControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockCityRepository = new Mock<ICityRepository>();
            _userManager = new Mock<UserManager<IdentityUser>>().Object;
            _userController = new UserController
                (_mockUserRepository.Object, _mockCityRepository.Object, _userManager);

            _tomJansens = _dummyContext.UserTomJansens;
            _tomJansensId = _tomJansens.UserId;
        }
        #endregion

        #region TestEditHttpGet
        [Fact]
        public void EddiHttpGet_ValidProductId_PassesUsersDetails()
        {
            var result = _userController.Edit() as ViewResult;
            result.ViewData["userId"] = _tomJansensId;
            var userViewModel = result?.Model as EditViewModel;
            Assert.Equal("Tom", userViewModel?.FirstName);
        }
        #endregion







    }
}