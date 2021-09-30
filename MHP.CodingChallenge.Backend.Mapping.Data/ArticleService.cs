using System;
using System.Collections.Generic;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private ArticleMapper _articleMapper;

        public ArticleService(ArticleRepository articleRepository, ArticleMapper articleMapper)
        {
            _articleRepository = articleRepository;
            _articleMapper = articleMapper;
        }

        public List<ArticleDto> GetAll()
        {
            List<Article> articles = _articleRepository.GetAll();
            List<ArticleDto> articleDtos = new List<ArticleDto>();
            // TODO 
            foreach (Article article in articles)
            {
                articleDtos.Add(_articleMapper.Map(article));
                
            }

            return articleDtos;
        }

        public object GetById(long id)
        {
            Article article = _articleRepository.FindById(id);
            ArticleDto articleDto = new ArticleDto();
            if (article != null)
            {
                articleDto = _articleMapper.Map(article);
                return articleDto;
            }
                return null;
            
                
            
        }

        public object Create(ArticleDto articleDto)
        {
            Article create = _articleMapper.Map(articleDto);
            _articleRepository.Create(create);
            return _articleMapper.Map(create);
        }
    }
}
