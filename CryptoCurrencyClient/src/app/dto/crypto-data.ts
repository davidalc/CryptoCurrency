export class CryptoData {
    name: string;
    symbol: string;
  
    metrics: CryptoMetrics;
  }
  
  export class CryptoMetrics {
    market_data: CryptoMarketData;
    marketcap: CryptoMaketCap;
  }
  
  export class CryptoMarketData {
    price_usd: number;
  }
  
  export class CryptoMaketCap {
    current_marketcap_usd: number;
  }
  