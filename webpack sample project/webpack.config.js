//webpack.config.js
var webpack = require('webpack');
module.exports = {
  devtool: 'eval-source-map',
  entry:  __dirname + "/app/main.js",//�Ѷ���ἰ��Ψһ����ļ�
  output: {
    path: __dirname + "/public",//�������ļ���ŵĵط�
    filename: "bundle.js"//���������ļ����ļ���
  },
	module: {//�������ļ�������JSON loader
    loaders: [
      {
        test: /\.json$/,
        loader: "json-loader"
      },
	{
        test: /\.js$/,
        exclude: /node_modules/,
        loader: 'babel-loader'//��webpack��module���ֵ�loaders��������ü���
      },
		  {
        test: /\.css$/,
        loader: 'style-loader!css-loader?modules'//���Ӷ���ʽ���Ĵ���
      }
    ]
  },
		
 // postcss: [
    //require('autoprefixer')//����autoprefixer���
  //],
  plugins: [
    new webpack.BannerPlugin("Copyright Flying Unicorns inc.")//�����������newһ���Ϳ�����
  ],
	devServer: {
    contentBase: "./public",//���ط����������ص�ҳ�����ڵ�Ŀ¼
    colors: true,//�ն���������Ϊ��ɫ
    historyApiFallback: true,//����ת
    inline: true//ʵʱˢ��
  } 
}